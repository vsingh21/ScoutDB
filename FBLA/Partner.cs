using System;

// Partner class representing a partner entity
public class Partner
{
    // parametized constructor
    public Partner(string organization, string type, string resources, string contactPerson, string contactEmail, string contactPhone)
    {
        Organization = organization;
        Type = type;
        Resources = resources;
        ContactPerson = contactPerson;
        ContactEmail = contactEmail;
        ContactPhone = contactPhone;
    }
    // getters and setters
    public string Organization { get; set; }
    public string Type { get; set; }
    public string Resources { get; set; }
    public string ContactPerson { get; set; }
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }
}
