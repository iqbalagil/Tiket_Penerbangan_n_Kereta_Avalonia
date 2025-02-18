using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.Services;

public class AuthState
{
    public Penumpang? CurrentUser { get; private set; }

    public void SetUser(Penumpang user)
    {
        CurrentUser = user;
    }

    public void Logout()
    {
        CurrentUser = null;
        
    }

    public bool IsAuth => CurrentUser != null;
}