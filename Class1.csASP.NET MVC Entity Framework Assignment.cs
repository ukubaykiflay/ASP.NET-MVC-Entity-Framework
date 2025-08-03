

using system.Ling;
using system, Web
using Car_ Insurance. Models;

namespace Car_ Insurance.Controllers
{
	public class InsureeController : controller
{
    private InsuranceEntities db = new InsuranceEntities();
    // Get: Insuree
    public ActionResult Index()
    {
        retun view(db.Insurees.ToList());
    }
    // Post : Calculate Quote[HttpPost]
    public ActionResult CalculateQuote(int id)
    {
        var insuree = db.Insurees.find(id);
        if (insuree == null)
        {
            return HttpNotFound();
        }
        // Bass monthly total
        decimal monthlyTotal = 50;
        // Calculate age
        int age = DateTime.Now.Year - insuree.DateOfBirth.Year;
        if (insuree.DateOfBirth > DateTime.Now.AddYears(-age)) age--;
        // Add to monthly total based on age
        if (age <= 18)
        {
            monthlyTotal += 100;
        }
        else if (age >= 19 && age <= 25)
        {
            monthlyTotal += 50;
        }
        else if (age >= 26)
        {
            monthlyTotal += 25;
        }
        // Add to monthly total based on car year
        if (insuree.CarYear < 2000)
        {
            monthlyTotal += 25;
        }
        else if (insuree.CarYear > 2015)
        {
            monthlyTotal += 25;
        }
        // Add to monthly total based on car make 
        if (insuree.CarMake.Equals("Porsche, StringComparison.OrdinalIgnoreCase"))
        {
            monthlyTotal += 25;
        }
        // Add cost based on car make and model
        if (insuree.CarMake.Equals("Porsche", StringComparion.OrdilIgnoreCase) &&
            insuree.CarModel.Equals("911 Carrera", StringComparion.ordinalIgnoreCase))
        {
            monthlyTotal += 25;
            // save the calculated quote
            insuree.Quote = monthlyTotal;
            db.Entry(insuree).State = EntityState, Modified;
            db.saveChanges();
            // Return the updateed insuree details
            return redirectToAction("Index");
        }
        return View(insuree);
    }
    public ActionResult Admin()
    {
        var insurees = db.Insurees.Tolist();
        return view(insurees);
    }
    @model IEnumerable<YourNamespace.Models.Insuree>
        <h2>Admin - All Quotes</h2>
        <table class="table">
        <thead>
        <tr>
        <th>Name</th>
        <th>Date of Birth</th>
        <th>Car Year</th>
        <th>Quote</th>
                                 </tr>
                                 </thead>
                                 <tbody>
                                 @foreach (var insuree in Model)
    {
        < tr >
            < td > @Insuree.Name </ td >
            < td > @Insuree.DateOfBirth.ToShortDateString() </ td >
            < td > @Insuree.CarYear </ td >
            < td > Insuree.Quote.TOString("C") </ td >
            </ tr >
            }
    </tbody>
        </table>


}


}





            ;
        }
    }
}

            
            


