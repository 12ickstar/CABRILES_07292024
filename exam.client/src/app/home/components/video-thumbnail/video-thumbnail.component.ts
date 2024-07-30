import { Component, Input, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { Upload } from '../../../shared/models/shared.model';
import { environment } from '../../../../../environments/environment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-video-thumbnail',
  templateUrl: './video-thumbnail.component.html',
  styleUrls: ['./video-thumbnail.component.css']
})
export class VideoThumbnailComponent {
  @Input() upload!: Upload;

  apiUrl: string = environment.apiUrl;
  constructor(private router: Router) { }

  navigateToStream(): void {
    debugger;
    this.router.navigate(['/streaming'], { queryParams: { id: this.upload.id } });
  }
}
