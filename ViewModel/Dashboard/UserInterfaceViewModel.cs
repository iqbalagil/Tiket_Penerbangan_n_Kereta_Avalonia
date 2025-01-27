using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

public class UserInterfaceViewModel : ViewModelBase
{
   private readonly ApplicationDbContext _context;
   private ObservableCollection<UserData> _datas;

   public ObservableCollection<UserData> Datas
   {
      get => _datas;
      set => SetProperty(ref _datas, value);
   }

   public UserInterfaceViewModel(ApplicationDbContext context)
   {
      _context = context;
      Datas = new ObservableCollection<UserData>();
      LoadData();
   }

   private async void LoadData()
   {
      var data = await _context.UserData.ToListAsync();
      foreach (var item in data)
      {
         Datas.Add(item);  
      }
   }
}