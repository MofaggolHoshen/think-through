using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitEventDeligate;
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public event Func<string, Task> OnEmailChanged;

    public async Task Update(Person person)
    {
        this.Id = person.Id;

        if (person.Name != this.Name)
            this.Name = person.Name;

        if (person.Email != this.Email)
        {
            if (this.OnEmailChanged != null)
                await OnEmailChanged.Invoke(person.Email);

            this.Email = person.Email;

        }
    }
}