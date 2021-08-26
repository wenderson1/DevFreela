using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserDetailsViewModel GetById(int id);
        List<UserDetailsViewModel> GetAll(string query);
        // int Create(NewUserInputModel inputModel);
        // void Update(UpdateUserInputModel inputModel);
        //void Delete(int id);
    }
}
