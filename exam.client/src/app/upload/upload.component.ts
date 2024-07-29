import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {
  uploadForm: FormGroup;
  categories: string[] = ['Music', 'Education', 'Comedy', 'Sports', 'News'];
  selectedFile: File | null = null;

  constructor(private fb: FormBuilder) {
    this.uploadForm = this.fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      categories: ['', Validators.required],
    });
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
      const formData = new FormData();
      formData.append('title', this.uploadForm.get('title')?.value);
      formData.append('description', this.uploadForm.get('description')?.value);
      formData.append('categories', this.uploadForm.get('categories')?.value);
      formData.append('video', this.selectedFile);

      console.log('Form Submitted', formData);
    }
  }
}