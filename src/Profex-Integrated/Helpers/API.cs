namespace Profex_Integrated.Helpers;

public class API
{
    public static readonly string BASEIMG_URL = "http://64.227.42.134:5075/";
    public static readonly string BASE_URL = "http://64.227.42.134:5075/api/";
    public static readonly string REGISTER_URL = BASE_URL + "master/register";
    public static readonly string SENDCODE_URL = BASE_URL + "master/register/send-code";
    public static readonly string VERIFY_URL = BASE_URL + "master/register/verify";
    public static readonly string LOGIN_URL = BASE_URL + "master/register/login";


    public static readonly string USERREGISTER_URL = BASE_URL + "user/register";
    public static readonly string USERSENDCODE_URL = BASE_URL + "user/register/send-code";
    public static readonly string USERVERIFY_URL = BASE_URL + "user/register/verify";
    public static readonly string USERLOGIN_URL = BASE_URL + "user/login";



    public static readonly string GETALL_MASTERS = BASE_URL + "common/masters";
    public static readonly string GETBYID_MASTERS = BASE_URL + "common/masters/skills";


    public static readonly string SEARCH_MASTERS = BASE_URL + "common/masters/search";
    public static readonly string SEARCH_VACANCY = BASE_URL + "common/posts/search";
    public static readonly string UPDATE_MASTERS = BASE_URL + "masters";

    //Vacancies part
    public static readonly string GETALL_VACANCY = BASE_URL + "common/posts";


    public static readonly string CREATE_IMAGE_POST = BASE_URL + "user/posts/images";

    public static readonly string UPDATE_IMAGE_POST = BASE_URL + "user/posts/images";
    



    public static readonly string GETBYID_VACANCY = BASE_URL + "common/posts";



    //Users part
    public static readonly string COUNT_USERS = BASE_URL + "common/users/count";
    public static readonly string GETALL_USERS = BASE_URL + "common/users";
    public static readonly string GETBYID_USERS = BASE_URL + "common/users";
    public static readonly string REMOVE_MY_POST = BASE_URL + "user/posts";
    public static readonly string UPDATE_USER_PROFILE = BASE_URL + "user";
    
    public static readonly string CREATE_POST = BASE_URL + "user/posts";
    public static readonly string GET_ALL_MY_POSTS = BASE_URL + "common/posts/users";
    public static readonly string UPDATE_MY_POST = BASE_URL + "user/posts";

    //category part
    public static readonly string GET_ALL_CATEGORY = BASE_URL + "common/categories";


    // skill part
    public static readonly string GET_ALL_BY_CATEGORY_ID = BASE_URL + "common/skills/categories";
    

    public static readonly string GET_ADD_SKILL = BASE_URL + "masters/skill";
    //xatolik mavjud
    public static readonly string MY_ALL_SKILL = BASE_URL + "common/masters/skills";
    

    public static readonly string REMOVE_MY_SKILL = BASE_URL + "masters/skill";


    public static readonly string CATEGORY_GET_ALL = BASE_URL + "common/categories";





    public static readonly string GET_BY_SKILL_ID = BASE_URL + "common/skills";


    public static readonly string SENT_REQUEST = BASE_URL + "masters/post/requests";
    public static readonly string GET_ALL_REQUEST = BASE_URL + "masters/post/requests";

    public static readonly string GET_ALL_REQUEST_USESR = BASE_URL +"user/posts/requests";
    
}
