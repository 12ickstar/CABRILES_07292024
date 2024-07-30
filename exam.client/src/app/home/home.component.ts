import { HttpClient } from '@angular/common/http';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, tap } from 'rxjs';
import { UploadList } from './models/home.models';
import { UPLOAD_LIST_DEFAULT } from './constants/home.constants';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit, OnDestroy {

  private unsubscribe$ = new Subject<void>();

  uploadList: UploadList = UPLOAD_LIST_DEFAULT;

  constructor(private http: HttpClient) {

  }
  
  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
  ngOnInit(): void {
    this.http.get<UploadList>('Uploads')
      .pipe(
        tap(response => {
          this.uploadList = response;
        })
      )
      .subscribe();
  }

}
