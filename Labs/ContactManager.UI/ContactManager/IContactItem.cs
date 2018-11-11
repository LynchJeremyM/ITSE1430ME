// ITSE-1430-20630
// Jeremy Lynch
// 11/20/18

namespace ContactManager
{
    public interface IContactItem
    {
        string ContactName { get; set; }
        string EmailAddress { get; set; }
    }
}