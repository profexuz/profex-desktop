namespace Profex_Integrated.Security;

public class IdentitySingelton
{
    private static IdentitySingelton _identitySingelton;

    public string Token { get; set; }
    public long Id { get; set; }

    private IdentitySingelton()
    {
    }

    public static IdentitySingelton GetInstance()
    {
        if (_identitySingelton is null)
            _identitySingelton = new IdentitySingelton();
        return _identitySingelton;

    }
}
