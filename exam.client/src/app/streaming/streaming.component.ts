import { HttpClient } from '@angular/common/http';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject, takeUntil, tap } from 'rxjs';
import { Upload } from '../shared/models/shared.model';
import { UPLOAD_DEFAULT } from '../shared/constants/shared.constants';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-streaming',
  templateUrl: './streaming.component.html',
  styleUrl: './streaming.component.css'
})
export class StreamingComponent implements OnInit, OnDestroy {

  private unsubscribe$ = new Subject<void>();
  upload: Upload = UPLOAD_DEFAULT;
  apiUrl: string = environment.apiUrl;
  videoUrl: string = '';

  constructor(
    private http: HttpClient,
    private route: ActivatedRoute
  ) { }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      const videoId = params['id'];
      if (videoId) {
        this.loadVideoById(videoId);
      }
    });
  }

  loadVideoById(id: string): void {
    this.http.get<Upload>(`Uploads/${id}`)
      .pipe(tap(upload => {
        this.upload = upload;
        this.videoUrl = `${this.apiUrl}${this.upload.videoFilePath}`;
      }),
      takeUntil(this.unsubscribe$))
      .subscribe();
  }

}
