using VTC.Common.ViewModels;

namespace VTC.BLL.Services.Interfaces
{
    public interface IMainService
    {
        Task AboutUsEdit(AboutUsViewModel model);
        Task ContactUsEdit(ContactUsViewModel model);
        List<AboutUsViewModel> GetAboutUs();
        ContactUsViewModel GetConactUs();
    }
}
