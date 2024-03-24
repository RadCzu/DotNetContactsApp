using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DotNetContactsApp.Areas.Identity.Data;


/*
 * 'Admin' user Authentication information (for testing):
 * Username: example
 * Email: example@example.com
 * Password: Example!@#123
 */
public class ContactsAppUser : IdentityUser
{
    //default fields are sufficient for this application
}

