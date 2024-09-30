namespace DbProject.Data
{
    //public class CustomPersonService
    //{
    //    private readonly ApplicationDbContext _context;

    //    public CustomPersonService(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<List<CustomPerson>> GetCustomPersonsWithEmails()
    //    {
    //        var query = from person in _context.CustomPersons
    //                    join email in _context.EmailAddresses
    //                    on person.CustomPersonID equals email.BusinessEntityID
    //                    group email by email.BusinessEntityID into groupedEmails
    //                    select new CustomPerson
    //                    {
    //                        CustomPersonID = groupedEmails.Key,
    //                        FirstName = person.FirstName,
    //                        LastName = person.LastName,
    //                        // Select the first email address only
    //                        EmailAddress = groupedEmails.FirstOrDefault().EmailAddress1
    //                    };

    //        return await query.ToListAsync();
    //    }
    //}

}