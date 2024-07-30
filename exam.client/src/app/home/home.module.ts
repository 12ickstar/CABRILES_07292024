import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { VideoThumbnailComponent } from './components/video-thumbnail/video-thumbnail.component';


@NgModule({
  declarations: [
    HomeComponent,
    VideoThumbnailComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule
  ]
})
export class HomeModule { }
