using DataLayer.Entities;

namespace CollegeManagement.Models;
public class PersonDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public IFormFile PhotoUrl { get; set; }

    public static implicit operator Instructor(PersonDTO vm)
    {
        return new Instructor
        {
            Id = vm.Id,
            Person = new Person
            {
                Name = vm.Name,
                Birthday = vm.Birthday,
                PhotoUrl = FileService.UploadAsync(vm.PhotoUrl).Result

            }
        };
    }
}

public class FileService
{
    public static async Task<string> UploadAsync(IFormFile file)
    {
        var rnd = Guid.NewGuid().ToString().Substring(0, 5);
        await using (var fileStream = new FileStream($"wwwroot/upload/{rnd}_{file.FileName}", FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }
        return $"/upload/{rnd}_{file.FileName}";
    }
}

