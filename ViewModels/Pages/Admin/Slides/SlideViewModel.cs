using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Pages.Admin.Slides
{
    public class SlideViewModel
    {
       
        [System.ComponentModel.DataAnnotations.Display
        (
            Name = nameof(Resources.DataDictionary.StartDateTime),
            ResourceType = typeof(Resources.DataDictionary)
        )]
        public DateTime? StartDateTime { get; set; }


        [System.ComponentModel.DataAnnotations.Display
        (
            Name = nameof(Resources.DataDictionary.FinishDateTime),
            ResourceType = typeof(Resources.DataDictionary)
        )]
        public DateTime? FinishDateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Required
        (AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.Messages.Validations),
            ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

        [System.ComponentModel.DataAnnotations.MaxLength
        (length: Domain.SeedWork.Constant.MaxLength.MainTitle,
            ErrorMessageResourceType = typeof(Resources.Messages.Validations),
            ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

        [System.ComponentModel.DataAnnotations.Display
        (
            Name = nameof(Resources.DataDictionary.MainTitle),
            ResourceType = typeof(Resources.DataDictionary)
        )]

        public string MainTitle { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength
        (length: Domain.SeedWork.Constant.MaxLength.SubTitle,
            ErrorMessageResourceType = typeof(Resources.Messages.Validations),
            ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

        [System.ComponentModel.DataAnnotations.Display
        (
            Name = nameof(Resources.DataDictionary.SubTitle),
            ResourceType = typeof(Resources.DataDictionary)
        )]
        public string SubTitle { get; set; }


        [System.ComponentModel.DataAnnotations.Display
        (
            Name = nameof(Resources.DataDictionary.Description),
            ResourceType = typeof(Resources.DataDictionary)
        )]
        public string Description { get; set; }


        [System.ComponentModel.DataAnnotations.Display
        (
            Name = nameof(Resources.DataDictionary.UrlLink),
            ResourceType = typeof(Resources.DataDictionary)
        )]
        public string UrlLink { get; set; }


        [System.ComponentModel.DataAnnotations.Display
        (
            Name = nameof(Resources.DataDictionary.IsActive),
            ResourceType = typeof(Resources.DataDictionary)
        )]
        public bool IsActive { get; set; }


        [System.ComponentModel.DataAnnotations.Display
        (
            Name = nameof(Resources.DataDictionary.OrderingNumber),
            ResourceType = typeof(Resources.DataDictionary)
        )]

        public byte OrderingNumber { get; set; }


    }
}
