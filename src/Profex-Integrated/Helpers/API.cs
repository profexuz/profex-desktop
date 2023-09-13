using static System.Net.WebRequestMethods;

namespace Profex_Integrated.Helpers;

public class API
{
    //public static readonly string BASEIMG_URL = "http://localhost:7145/";
    //public static readonly string BASE_URL = "http://localhost:5230/api/";
    public static readonly string BASEIMG_URL = "http://64.227.42.134:4040/";
    public static readonly string BASE_URL = "http://64.227.42.134:4040/api/";
    public static readonly string REGISTER_URL = BASE_URL + "master/register";
    public static readonly string SENDCODE_URL = BASE_URL + "master/register/send-code";
    public static readonly string VERIFY_URL = BASE_URL + "master/register/verify";
    public static readonly string LOGIN_URL = BASE_URL + "master/register/login";



    public static readonly string GETALL_MASTERS = BASE_URL + "common/master";
    public static readonly string GETBYID_MASTERS = BASE_URL + "common/master";
    public static readonly string SEARCH_MASTERS = BASE_URL + "common/master/search";
    public static readonly string SEARCH_VACANCY = BASE_URL + "common/post/search";
    //public static readonly string UPDATE_MASTERS = BASE_URL + "common/master";
    public static readonly string UPDATE_MASTERS = BASE_URL + "tokenmaster";
    //http://64.227.42.134:4040/api/tokenmaster

    //Vacancies part
    public static readonly string GETALL_VACANCY = BASE_URL + "common/post";
    

    //buni API ni korib chiqish kerak hali ishlamadi
    //public static readonly string GETBYID_VACANCY = BASE_URL + "common/post/join";
    public static readonly string GETBYID_VACANCY = BASE_URL + "common/post/byId";


    //Users part
    public static readonly string COUNT_USERS = BASE_URL + "common/user/count";

    public static readonly string GETALL_USERS = BASE_URL + "common/user/get-all";
    public static readonly string GETBYID_USERS = BASE_URL + "common/user/getbyId";

    //category part
    public static readonly string GET_ALL_CATEGORY = BASE_URL + "common/category";


    // skill part
    public static readonly string GET_ALL_BY_CATEGORY_ID = BASE_URL + "common/category/allSkillsBy/categoryId";
    //http://64.227.42.134:4040/api/common/category/allSkillsBy/categoryId?categoryId=2&page=1
    
    public static readonly string GET_BY_SKILL_ID = BASE_URL + "common/skills";
    //http://64.227.42.134:4040/api/common/skills/6
}
