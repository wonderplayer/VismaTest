using System.Collections.Generic;
using visma_test.Interface;
using visma_test.Models;
using Newtonsoft.Json;
using System.Linq;

namespace visma_test.Provider
{
    public class ServiceProvider : IServiceProvider
    {

        public ServiceProvider()
        {

        }
        private string Data = @"
        {
'data':
[
{
'Id': 1,
'Name': 'Rolands',
'Surname': 'Strakis',
'Phone': '25687489',
'Login': 'RolandsStrakis',
'Attempts' : [
'2012-04-23T18:25:43.511Z', '2013-04-23T18:25:43.511Z', '2014-04-23T18:25:43.511Z', '2015-04-23T18:25:43.511Z', '2016-04-23T18:25:43.511Z', '2012-05-23T18:25:43.511Z', '2013-04-23T18:25:43.511Z', '2014-06-23T18:25:43.511Z', '2015-04-23T11:25:43.511Z', '2016-04-23T15:25:43.511Z'
]
},
{
'Id': 2,
'Name': 'Edgars',
'Surname': 'Strakis',
'Phone': '23457125',
'Login': 'EdgarsStrakis',
'Attempts' : [
'2011-04-23T18:25:43.511Z', '2013-04-23T18:25:43.511Z', '2014-04-23T18:25:43.511Z', '2014-04-23T18:25:43.511Z', '2016-04-23T18:29:43.511Z', '2012-05-23T18:25:43.511Z', '2013-04-23T18:25:43.511Z', '2014-06-23T18:25:43.511Z', '2011-04-23T11:25:43.511Z', '2016-02-23T15:25:43.511Z'
]
},
{
'Id': 3,
'Name': 'Marks',
'Surname': 'Strakis',
'Phone': '25687489',
'Login': 'MarksStrakis',
'Attempts' : [
'2012-04-23T18:25:41.511Z', '2013-04-23T18:25:43.511Z', '2014-04-23T18:25:43.511Z', '2015-04-23T18:25:43.511Z', '2016-04-23T08:25:43.511Z', '2012-05-23T18:25:43.511Z', '2013-04-23T18:25:43.511Z', '2014-06-23T18:25:43.511Z', '2015-04-23T11:21:43.511Z', '2016-02-23T15:25:43.541Z'
]
},
{
'Id': 4,
'Name': 'Alberts',
'Surname': 'Strakis',
'Phone': '25687489',
'Login': 'AlbertsStrakis',
'Attempts' : [
'2012-04-23T18:25:43.521Z', '2013-04-23T18:25:40.511Z', '2014-04-23T18:05:43.511Z', '2011-04-23T18:25:43.511Z', '2016-04-23T18:25:43.511Z', '2012-05-23T18:25:43.511Z', '2013-04-23T18:25:43.511Z', '2014-06-25T18:25:43.571Z', '2015-04-23T11:25:43.511Z', '2016-01-23T15:25:43.511Z'
]
}
]}
        ";
        public List<UserViewModel> Users
        {
            get => ParseData.data
                .Select(i => new UserViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Surname = i.Surname
                })
                .ToList();
        }
        public UserInfoViewModel User(int id)
        {
            var person = ParseData.data
            .Where(u => u.Id == id)
            .Select(i => new UserInfoViewModel
            {
                Id = i.Id,
                Login = i.Login,
                Phone = i.Phone,
                Attempts = i.Attempts
            })
            .FirstOrDefault();
            person?.Attempts.Sort();
            return person;
        }
        private DataModel ParseData
        {
            get => (JsonConvert.DeserializeObject<DataModel>(Data));
        }
    }
}