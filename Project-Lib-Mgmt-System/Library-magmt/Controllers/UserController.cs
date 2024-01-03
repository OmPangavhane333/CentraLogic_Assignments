using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Container = Microsoft.Azure.Cosmos.Container;
using System.ComponentModel;
using Microsoft.Azure.Cosmos;
using Library_magmt.DTO;
using Library_magmt.Entity;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Identity;

namespace Library_magmt.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public Container container;
        public UserController()
        {
            container = GetContainer();
        }

        [HttpPost]
        public async Task<IActionResult> UserSignUp(UserSignUpDTO userSignUpDTO)
        {
            try
            {
                Users UserEntity = new Users();

                UserEntity.UId = userSignUpDTO.UId;
                UserEntity.UserName = userSignUpDTO.UserName;
                UserEntity.UserPassword = userSignUpDTO.UserPassword;
                UserEntity.ConfirmPassword = userSignUpDTO.ConfirmPassword;
                UserEntity.UserFullname = userSignUpDTO.UserFullname;
                UserEntity.UserPrnNo = userSignUpDTO.UserPrnNo;
                UserEntity.UserAge = userSignUpDTO.UserAge;

                UserEntity.Id = Guid.NewGuid().ToString();
                UserEntity.UId = UserEntity.Id;
                UserEntity.DocumentType = "UserDetails";

                UserEntity.CreatedOn = DateTime.Now;
                UserEntity.CreatedByName = "Om Pangavhane";
                UserEntity.CreatedBy = "UId";

                UserEntity.UpdateOn = DateTime.Now;
                UserEntity.UpdateByName = "Om Pangavhane";
                UserEntity.UpdateBy = "UId";

                UserEntity.Version = 1;
                UserEntity.Active = true;
                UserEntity.Archieved = false;

                Users response = await container.CreateItemAsync(UserEntity);
                UserSignUpDTO usersignup = new UserSignUpDTO();

                // Reverse Mapping
                UserEntity.UId = response.UId;
                UserEntity.UserName = response.UserName;
                UserEntity.UserPassword = response.UserPassword;
                UserEntity.ConfirmPassword = response.ConfirmPassword;
                UserEntity.UserFullname = response.UserFullname;
                UserEntity.UserPrnNo = response.UserPrnNo;
                UserEntity.UserAge = response.UserAge;

                if (response.UserPassword != response.ConfirmPassword) 
                {
                    return BadRequest("Password and confirm Password is not Matching" + response.ConfirmPassword);
                }                   
 


                return Ok(usersignup);
            }
            catch (Exception ex) 
            {
                return BadRequest("Something Went Wrong...!!");
            }
        }

        [HttpGet]
        public IActionResult UserLogIn(string UserName, String UserPassword)
        {
            try 
            {
                Users UserEntity = container.GetItemLinqQueryable<Users>(true).Where(a => 
                a.DocumentType == "UserDetails" && a.UserName == UserName &&
                a.UserPassword == UserPassword ).AsEnumerable().FirstOrDefault();

                var UserLogin = new UserLogin();
                UserLogin.UId = UserEntity.UId;
                UserLogin.UserName = UserEntity.UserName;
                UserLogin.UserFullname = UserEntity.UserFullname;
                UserLogin.UserPrnNo = UserEntity.UserPrnNo;

                return Ok(UserLogin);
            }
            catch 
            {
                return BadRequest("Something Went Wrong, Login failed\nPlease try again after some time.");
            }

        }



        private Container GetContainer()
        {
            string URI = Environment.GetEnvironmentVariable("cosmos-url");
            string PrimaryKey = Environment.GetEnvironmentVariable("Primary-Key");
            string DatabaseName = Environment.GetEnvironmentVariable("Database-name");
            string ContainerName = Environment.GetEnvironmentVariable("Container-name");

            CosmosClient cosmoscClient = new CosmosClient(URI, PrimaryKey);

            Database db = cosmoscClient.GetDatabase(DatabaseName);

            Container container = db.GetContainer(ContainerName);

            return container;
        }
    }
}
