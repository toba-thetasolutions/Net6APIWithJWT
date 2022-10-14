namespace Net6APIWithJWT.Models
{
    // We are not taking data from data base so we get data from constant
    public class UserConstants
    {
        public static List<UserModel> Users = new()
            {
                    new UserModel(){ Username="admin",Password="admin",Role="Admin"},
                    new UserModel(){ Username="hr",Password="hr",Role="HRAdmin"}
            };
    }
}
