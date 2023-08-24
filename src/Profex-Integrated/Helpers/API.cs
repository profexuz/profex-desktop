namespace Profex_Integrated.Helpers;

public class API
{
    public static readonly string BASEIMG_URL = "http://95.130.227.187";
    public static readonly string BASE_URL = "http://95.130.227.187/api/";
    public static readonly string REGISTER_URL = BASE_URL+"master/register";
    public static readonly string SENDCODE_URL = BASE_URL+"master/register/send-code";
    public static readonly string VERIFY_URL = BASE_URL+"master/register/verify";
    public static readonly string LOGIN_URL = BASE_URL + "master/register/login";

    public static readonly string GETALL_MASTERS = BASE_URL + "common/master";
    public static readonly string GETBYID_MASTERS = BASE_URL + "common/master";
    public static readonly string SEARCH_MASTERS = BASE_URL + "common/master/search";
    public static readonly string UPDATE_MASTERS = BASE_URL + "common/master";


    //Vacancies part
    public static readonly string GETALL_VACANCY = BASE_URL + "common/post";
    public static readonly string GETBYID_VACANCY = BASE_URL + "common/post/join";


    //Users part
    public static readonly string COUNT_USERS = BASE_URL + "common/user/count";
    public static readonly string GETALL_USERS = BASE_URL + "common/user/get-all";
    public static readonly string GETBYID_USERS = BASE_URL + "common/user/getbyId";

}
