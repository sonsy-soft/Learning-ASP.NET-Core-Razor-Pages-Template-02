using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Slides
{
    public class SliderConfiguration
        :
            object, Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Cms.Slides.Slider>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata
            .Builders.EntityTypeBuilder<Domain.Cms.Slides.Slider> builder)
        {
            
            builder
                .Property(current => current.MainTitle)
                .HasMaxLength(maxLength: Domain.SeedWork.Constant.MaxLength.MainTitle)
                .IsRequired(required: true)
                .IsUnicode(unicode: true)
                ;

            builder
                .Property(current => current.SubTitle)
                .HasMaxLength(maxLength: Domain.SeedWork.Constant.MaxLength.SubTitle)
                .IsRequired(required: false)
                .IsUnicode(unicode: true)
                ;

            builder
                .Property(current => current.Description)
                .IsRequired(required: false)
                .IsUnicode(unicode: true)
                ;

            builder
                .Property(current => current.UrlLink)
                .IsRequired(required: false)
                .IsUnicode(unicode: true)
                ;

            builder
                .Property(current => current.InsertDateTime)
                .HasColumnType(typeName: nameof(System.DateTime.Date))
                ;

            builder
                .Property(current => current.UpdateDateTime)
                .HasColumnType(typeName: nameof(System.DateTime.Date))
                ;
            builder
                .Property(current => current.UpdateDateTime)
                .HasColumnType(typeName: nameof(System.DateTime.Date))
                ;

            builder
                .Property(current => current.StartDateTime)
                .HasColumnType(typeName: nameof(System.DateTime.Date))
                ;

            builder
                .Property(current => current.FinishDateTime)
                .HasColumnType(typeName: nameof(System.DateTime.Date))
                ;

        }
    }
}
