using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SecureGiveChallenge.Controllers;
using SecureGiveChallenge.Models;
using System;

namespace SecureGiveTestProject
{
    public class SecureGiveTests
    {
        // "CREATE" Test
        [Fact]
        public void SuccessfulUserAddition()
        {            
            SecureGiveChallenge.Models.User user = new SecureGiveChallenge.Models.User();            

            user.FirstName = "Greg";
            user.LastName = "Johnson";
            user.UserType = 'E';
            
            int userCount = SampleData.UsersList.Count();
            SampleData.Create(user);
                                                           
            Assert.Equal(userCount + 1, SampleData.UsersList.Count()); 
                        
        }

        // "READ" Test
        [Fact]
        public void SuccessfulUserRetrieval()
        {
            SecureGiveChallenge.Models.User user = new SecureGiveChallenge.Models.User();

            user.FirstName = "Greg";
            user.LastName = "Johnson";
            user.UserType = 'E';
            
            SampleData.Create(user);

            var foundRecord = SampleData.UsersList.FirstOrDefault(x => x.FirstName == "Greg" && x.LastName == "Johnson");
            Assert.NotNull(foundRecord);
            
        }


        // "UPDATE" Test
        [Fact]
        public void SuccessfulUserUpdate()
        {
            SecureGiveChallenge.Models.User user = new SecureGiveChallenge.Models.User();

            user.FirstName = "Greg";
            user.LastName = "Johnson";
            user.UserType = 'E';

            SampleData.Create(user);
            int recordId = SampleData.UsersList.FirstOrDefault().UserId;

            user.UserType = 'V';
            SampleData.Update(user, recordId);
            Assert.Equal(user.UserType, SampleData.UsersList.FirstOrDefault(x => x.UserId == user.UserId).UserType);

            
        }

        // "DELETE" Test
        [Fact]
        public async void SuccessfulUserDeletion()
        {
                       
            SecureGiveChallenge.Models.User user = new SecureGiveChallenge.Models.User();
            SecureGiveChallenge.Models.SampleData dataGroup = new SampleData();

            user.FirstName = "Greg";
            user.LastName = "Johnson";
            user.UserType = 'E';            
            SampleData.Create(user);

            int userId = SampleData.UsersList.FirstOrDefault(x => x.FirstName == "Greg").UserId;
            
            SampleData.Delete(user);

            var foundRecord = SampleData.UsersList.FirstOrDefault(x => x.UserId == userId);            

            Assert.Null(foundRecord);
            
            
        }
    }
}