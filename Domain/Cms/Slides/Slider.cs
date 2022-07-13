using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cms.Slides
{
    public  class Slider : SeedWork.Entity, SeedWork.IEntityHasIsActive, SeedWork.IEntityHasUpdateDateTime
    {
        public Slider() : base()
        {
            IsActive = false; 
        }


        [System.ComponentModel.DataAnnotations.Display
        (Name = nameof(Resources.DataDictionary.InsertDateTime),
            ResourceType = typeof(Resources.DataDictionary))]
        public DateTime     InsertDateTime      { get; set; }


        [System.ComponentModel.DataAnnotations.Display
        (
            Name            = nameof(Resources.DataDictionary.UpdateDateTime),
            ResourceType    = typeof(Resources.DataDictionary)
        )]
        public DateTime     UpdateDateTime      { get; set; }


        [System.ComponentModel.DataAnnotations.Display
        (
            Name = nameof(Resources.DataDictionary.StartDateTime),
            ResourceType = typeof(Resources.DataDictionary)
        )]
        public DateTime?     StartDateTime       { get; set; }


        [System.ComponentModel.DataAnnotations.Display
        (
            Name = nameof(Resources.DataDictionary.FinishDateTime),
            ResourceType = typeof(Resources.DataDictionary)
        )]
        public DateTime?     FinishDateTime      { get; set; }

        [System.ComponentModel.DataAnnotations.Display
        (
            Name = nameof(Resources.DataDictionary.MainTitle),
            ResourceType = typeof(Resources.DataDictionary)
        )]
       
        public string       MainTitle           { get; set; }


        [System.ComponentModel.DataAnnotations.Display
        (
            Name = nameof(Resources.DataDictionary.SubTitle),
            ResourceType = typeof(Resources.DataDictionary)
        )]
        public string       SubTitle            { get; set; }


        [System.ComponentModel.DataAnnotations.Display
        (
            Name = nameof(Resources.DataDictionary.Description),
            ResourceType = typeof(Resources.DataDictionary)
        )]
        public string       Description         { get; set; }


        [System.ComponentModel.DataAnnotations.Display
        (
            Name = nameof(Resources.DataDictionary.UrlLink),
            ResourceType = typeof(Resources.DataDictionary)
        )]
        public string       UrlLink             { get; set; }


        [System.ComponentModel.DataAnnotations.Display
        (
            Name = nameof(Resources.DataDictionary.IsActive),
            ResourceType = typeof(Resources.DataDictionary)
        )]
        public bool         IsActive            { get; set; }


        [System.ComponentModel.DataAnnotations.Display
        (
            Name = nameof(Resources.DataDictionary.OrderingNumber),
            ResourceType = typeof(Resources.DataDictionary)
        )]
       
        public byte         OrderingNumber      { get; set; }

        public void SetUpdateDateTime()
        {
            UpdateDateTime = SeedWork.Utility.Now;
        }
    }
}
