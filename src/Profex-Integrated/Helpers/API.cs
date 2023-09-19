using static System.Net.WebRequestMethods;

namespace Profex_Integrated.Helpers;

public class API
{
    public static readonly string BASEIMG_URL = "http://64.227.42.134:4040/";
    public static readonly string BASE_URL = "http://64.227.42.134:4040/api/";
    public static readonly string REGISTER_URL = BASE_URL + "master/register";
    public static readonly string SENDCODE_URL = BASE_URL + "master/register/send-code";
    public static readonly string VERIFY_URL = BASE_URL + "master/register/verify";
    public static readonly string LOGIN_URL = BASE_URL + "master/register/login";


    public static readonly string USERREGISTER_URL = BASE_URL + "user/register";
    public static readonly string USERSENDCODE_URL = BASE_URL + "user/register/send-code";
    public static readonly string USERVERIFY_URL = BASE_URL + "user/register/verify";
    public static readonly string USERLOGIN_URL = BASE_URL + "user/login";



    public static readonly string GETALL_MASTERS = BASE_URL + "common/master";
    //  public static readonly string GETBYID_MASTERS = BASE_URL + "common/master";

    public static readonly string GETBYID_MASTERS = BASE_URL + "common/master/withSkills";
    //http://64.227.42.134:4040/api/common/master/withSkills/12


    public static readonly string SEARCH_MASTERS = BASE_URL + "common/master/search";
    public static readonly string SEARCH_VACANCY = BASE_URL + "common/post/search";
    //public static readonly string UPDATE_MASTERS = BASE_URL + "common/master";
    public static readonly string UPDATE_MASTERS = BASE_URL + "tokenmaster";
    //http://64.227.42.134:4040/api/tokenmaster

    //Vacancies part
    public static readonly string GETALL_VACANCY = BASE_URL + "common/post";


    
    //public static readonly string GETBYID_VACANCY = BASE_URL + "common/post/join";
    public static readonly string GETBYID_VACANCY = BASE_URL + "common/post/byId";


    //Users part
    public static readonly string COUNT_USERS = BASE_URL + "common/user/count";
    public static readonly string GETALL_USERS = BASE_URL + "common/user/get-all";
    public static readonly string GETBYID_USERS = BASE_URL + "common/user/getbyId";
    public static readonly string REMOVE_MY_POST = BASE_URL + "user/post";
    public static readonly string UPDATE_USER_PROFILE = BASE_URL + "tokenuser";
    public static readonly string CREATE_POST = BASE_URL + "user/post";
    public static readonly string GET_ALL_MY_POSTS = BASE_URL + "common/post/user";
                            //http://64.227.42.134:4040/api/common/post/user/6?page=1

    //category part
    public static readonly string GET_ALL_CATEGORY = BASE_URL + "common/category";


    // skill part
    public static readonly string GET_ALL_BY_CATEGORY_ID = BASE_URL + "common/category/allSkillsBy/categoryId";

    public static readonly string GET_ADD_SKILL = BASE_URL + "tokenmaster/addSkill";

    public static readonly string MY_ALL_SKILL = BASE_URL + "common/master/withSkills";

    public static readonly string REMOVE_MY_SKILL = BASE_URL + "tokenmaster/dSkill";

    


    //common/category/allSkillsBy/categoryId?categoryId=2&page=1

    public static readonly string GET_BY_SKILL_ID = BASE_URL + "common/skills";


    //requests parts http://64.227.42.134:4040/api/tokenmaster/request/post
    public static readonly string SENT_REQUEST = BASE_URL + "tokemaster/request/post";
                        //tokenmaster/posts/requested?page=1
    public static readonly string GET_ALL_REQUEST = BASE_URL + "tokenmaster/posts/requested";

    public static readonly string GET_ALL_REQUEST_USESR = BASE_URL +"user/post/all/withrequest";
    //http://64.227.42.134:4040/api/user/post/all/withrequest
}
