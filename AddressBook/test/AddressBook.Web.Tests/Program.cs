using Microsoft.AspNetCore.Builder;
using AddressBook;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<AddressBookWebTestModule>();

public partial class Program
{
}
