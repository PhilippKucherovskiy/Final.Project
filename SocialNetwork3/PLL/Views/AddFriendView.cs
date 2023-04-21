using SocialNetwork3.BLL.Exceptions;
using SocialNetwork3.BLL.Services;
using SocialNetwork3.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork3.PLL.Views
{/// <summary>
/// Добавлен класс с логикой добавления друга
/// </summary>
    public class AddFriendView
    {
        private readonly UserService userService;

        public AddFriendView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show()
        {
            Console.WriteLine("Введите Ваш email:");
            string userEmail = Console.ReadLine();

            Console.WriteLine("Введите email друга:");
            string friendEmail = Console.ReadLine();

            try
            {
                userService.AddFriend(userEmail, friendEmail);
                SuccessMessage.Show("Друг успешно добавлен!");
            }
            catch (UserNotFoundException ex)
            {
                AlertMessage.Show(ex.Message);
            }
        }
    }
}
