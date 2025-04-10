/// <summary>
/// Admin panelinde kullanıcıların listelendiği sayfa için kullanılan response modelidir.
/// Her bir kullanıcıya ait temel bilgilerden oluşan listeyi taşır.
/// </summary>
namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.AppUsers
{
    public class UserListViewResponseModel
    {
        public List<UserViewResponseModel> Users { get; set; }
    }
}
