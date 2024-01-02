using System;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerWithCRUD.Models;
using TaskManagerWithCRUD.Entity;
using TaskManagerWithCRUD.DTO;
using TaskManagerWithCRUD.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using Container = Microsoft.Azure.Cosmos.Container;
using System.ComponentModel;
using Microsoft.Azure.Cosmos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Task = System.Threading.Tasks.Task;

namespace TaskManagerWithCRUD.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public string URI = "https://localhost:8081";
        public string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        public string DatabaseName = "Week5";
        public string ContainerName = "cont2";

        public readonly Container container1;

        public EmployeeController()
        {
            container1 = GetContainer();
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(EmpDTO employeeDTO)
        {
            try
            {
                employee employeeEntity = new employee();

                employeeEntity.TaskName = employeeDTO.TaskName;
                employeeEntity.TaskDescription = employeeDTO.TaskDescription;

                employeeEntity.Id = Guid.NewGuid().ToString();
                employeeEntity.UId = employeeEntity.Id;
                employeeEntity.DocumentType = "Employee";

                employeeEntity.CreatedOn = DateTime.Now;
                employeeEntity.CreatedByName = "Om Pangavhane";
                employeeEntity.CreatedBy = "UId";

                employeeEntity.UpdateOn = DateTime.Now;
                employeeEntity.UpdateByName = "Om Pangavhane";
                employeeEntity.UpdateBy = "UId";

                employeeEntity.Version = 1;
                employeeEntity.Active = true;
                employeeEntity.Archieved = false;

                employee response = await container1.CreateItemAsync(employeeEntity);

                // Reverse Mapping 
                employeeEntity.TaskName = response.TaskName;
                employeeEntity.TaskDescription = response.TaskDescription;


                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Data Adding Failed" + ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask(string uId,string name, string taskDesc)
        {
            Employee existingTask = container1.GetItemLinqQueryable<Employee>(true).Where(q => q.DocumentType == "Employee" && q.UId == uId).AsEnumerable().FirstOrDefault();
            if (existingTask != null) 
            { 
                existingTask.UId = uId;
                existingTask.TaskName = name;
                existingTask.TaskDescription = taskDesc;
                existingTask.Version++;

                try 
                {
                    var response = await container1.UpsertItemAsync(existingTask, new PartitionKey(uId));
                    if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        return Ok("Task Updated Successfully!!");
                    }
                    else 
                    {
                        return BadRequest("Failed to update Task");
                    }
                }
                catch (Exception ex) 
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetAlltask()
        {
            try 
            {
                var tasks = container1.GetItemLinqQueryable<Employee>(true).AsEnumerable().ToList();

                return Ok(tasks);
            }
            catch (Exception ex) 
            {
                return BadRequest("Data Get Failed");

            }
        }

        [HttpGet]
        public IActionResult GettaskByUId(string UId)
        {
            try
            {
                // Step1 : Get all tasks
                var tasks = container1.GetItemLinqQueryable<Employee>(true).Where(q=> q.UId == UId && q.DocumentType == "Employee").AsEnumerable().FirstOrDefault();
                
                // Step 2 : Map all employee
                
                var taskModel = new EmployeeDTO();
                taskModel.UId = tasks.UId;
                taskModel.TaskName = tasks.TaskName;
                taskModel.TaskDescription = tasks.TaskDescription;

                return Ok(taskModel);
            }
            catch (Exception ex)
            {
                return BadRequest("Data Get Failed");
            }
        }

        [HttpDelete]
        public async Task DeleteTask(string UId) 
        {
            await container1.DeleteItemAsync<Employee>(UId, new PartitionKey(UId));
        }

        private Container GetContainer()
        {
            CosmosClient cosmoscClient = new CosmosClient(URI, PrimaryKey);
            Database database = cosmoscClient.GetDatabase(DatabaseName);
            Container container = database.GetContainer(ContainerName);
            return container;
        }
    }
}
