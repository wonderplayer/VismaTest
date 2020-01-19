using visma_test.Models;
using System.Collections.Generic;
namespace visma_test.Interface
{
    public interface IServiceProvider
    {
        List<UserViewModel> Users {get;}
        UserInfoViewModel User(int id);
    }
}
