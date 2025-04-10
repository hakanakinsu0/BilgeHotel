/// <summary>
/// Kullanıcı listeleme ekranında gösterilecek kullanıcıları içeren modeldir.
/// İçerisinde birden fazla kullanıcıya ait özet bilgileri barındıran liste bulunur.
/// </summary>
namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.AppUsers
{
    public class UserListResponseModel
    {
        public List<UserViewResponseModel> Users { get; set; }
    }
}
