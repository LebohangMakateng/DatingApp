import { Component, OnInit } from '@angular/core';
import { Photo } from '../_models/photo';
import { AdminService } from '../_services/admin.service';

@Component({
  selector: 'app-photo-management',
  templateUrl: './photo-management.component.html',
  styleUrls: ['./photo-management.component.css']
})
export class PhotoManagementComponent implements OnInit {
  photos: Photo[];

  constructor(private adminServcie: AdminService) { }

  ngOnInit(): void {
  }
 
  getphotosForApproval() {
    this.adminServcie.getPhotosForApproval().subscribe(photos => {
      this.photos = photos;
    })
  }

  approvePhoto(photoid) {
    this.adminServcie.approvePhoto(photoid).subscribe(() => {
      this.photos.splice(this.photos.findIndex(p => p.id === photoid), 1);
    })
  }

  rejectphoto(photoid) {
    this.adminServcie.rejectPhoto(photoid).subscribe(() => {
      this.photos.splice(this.photos.findIndex(p => p.id === photoid), 1);
    })
  }

}
