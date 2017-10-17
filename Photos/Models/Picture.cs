//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Photos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Picture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Picture()
        {
            this.Categories = new HashSet<Category>();
        }
    
        public int PictureId { get; set; }
        public System.DateTime DateTaken { get; set; }
        public string PhotoDescription { get; set; }
        public int PlaceId { get; set; }
        public string FileName { get; set; }
        public Nullable<int> FolderId { get; set; }
    
        public virtual Folder Folder { get; set; }
        public virtual Place Place { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories { get; set; }
    }
}
