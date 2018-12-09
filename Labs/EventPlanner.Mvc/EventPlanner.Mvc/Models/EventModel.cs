/* Jeremy Lynch
 * ITSE 1430
 * 12/9/2018
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Mvc.Models
{
    public class EventModel : IValidatableObject
    {
        public EventModel() { }

        public EventModel(ScheduledEvent evt)
        {
            if (evt != null)
            {
                Id = evt.Id;
                Name = evt.Name;
                Description = evt.Description;
                StartDate = evt.StartDate;
                EndDate = evt.EndDate;
                IsPublic = evt.IsPublic;
            }
        }

        public ScheduledEvent ToDomain()
        {
            return new ScheduledEvent()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                StartDate = StartDate,
                EndDate = EndDate,
                IsPublic = IsPublic
            };
        }

        /// <summary>Gets or sets the unique ID.</summary>
        [Range(0, Int32.MaxValue)]
        public int Id { get; set; }

        /// <summary>Gets or sets the unique name.</summary>
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        /// <summary>Gets or sets the description.</summary>
        public string Description { get; set; }

        /// <summary>Gets or sets the start date.</summary>
        [Display(Name ="Start Date")]
        public DateTime StartDate { get; set; }

        /// <summary>Gets or sets the end date.</summary>
        [Display(Name="End Date")]
        public DateTime EndDate { get; set; }

        /// <summary>Determines if this is private or public event.</summary>
        public bool IsPublic { get; set; }

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            if (EndDate < StartDate)
                yield return new ValidationResult("End date must be greater than or equal to start date.", new[] { nameof(EndDate) });
        }
    }
}