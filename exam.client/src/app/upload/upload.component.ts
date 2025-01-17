import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subject, catchError, finalize, takeUntil, tap } from 'rxjs';
import { UploadVideoResponse } from './models/upload.models';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit, OnDestroy {

  @ViewChild('uploadToast') uploadToast!: ElementRef;
  private unsubscribe$ = new Subject<void>();

  uploadForm: FormGroup;
  categories: string[] = ['Music', 'Education', 'Comedy', 'Sports', 'News'];
  selectedFile: File | null = null;
  isUploading = false;
  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private router: Router,
    private toastr: ToastrService) {
    this.uploadForm = this.fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      categories: ['', Validators.required],
    });
  }
  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  ngOnInit(): void {
  }

  onFileChange(event: any): void {
    const file = event.target.files[0];
    if (file) {
      this.selectedFile = file;
    }
  }

  onSubmit(): void {
    if (this.uploadForm.valid && this.selectedFile) {
      this.isUploading = true;

      const formData = new FormData();
      formData.append('title', this.uploadForm.get('title')?.value);
      formData.append('description', this.uploadForm.get('description')?.value);
      formData.append('categories', this.uploadForm.get('categories')?.value);
      formData.append('video', this.selectedFile);

      this.http.post<UploadVideoResponse>(`Uploads`, formData)
        .pipe(
          tap((response: UploadVideoResponse) => {
            this.router.navigate(['/streaming'], { queryParams: { id: response.id } });
            this.toastr.success('Upload successful!', 'Success');
          }), 
          catchError((error: HttpErrorResponse) => {
            this.toastr.error('An error occurred during the upload. Please try again.', 'Error');
            throw error;
          }),
          finalize(() => {
            this.isUploading = false;
          }),
          takeUntil(this.unsubscribe$)
        )
        .subscribe();
    }
  }
}