using ariel_my_friend.Data;
using ariel_my_friend.Dto;
using ariel_my_friend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using static ariel_my_friend.Utils.ImageUtils;

namespace ariel_my_friend.Controllers
{
    public class FriendController: Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public FriendController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index()
        {
          var friends = _dbContext.Friends.Include(f => f.Images).ToList();
          return View(friends);
        }
        public IActionResult Create() => View(new CreateFriendDto());

        [HttpPost]
        public IActionResult Create(CreateFriendDto createFriendDto)
        {
            if (!ModelState.IsValid) { return RedirectToAction("Index"); }
            FriendModel modelToSave = new()
            {
                FirstName = createFriendDto.FirstName,
                LastName = createFriendDto.LastName,
                Images = createFriendDto.Image != null 
                ? [new () { Data = ConvertFromIFormFile(createFriendDto.Image)! }]
                : [] 
            };

            _dbContext.Friends.Add(modelToSave);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
