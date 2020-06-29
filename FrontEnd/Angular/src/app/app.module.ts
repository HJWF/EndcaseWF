import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatToolbarModule } from '@angular/material/toolbar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';

import { AppComponent } from './app.component';
import { CursusListComponent } from './cursus-list/cursus-list.component';
import CursusService from './shared/api/cursus.service'

const appRoutes: Routes = [
  { path: '', redirectTo: '/cursus-list', pathMatch: 'full' },
  {
    path: 'cursus-list',
    component: CursusListComponent
  }
];

@NgModule({
  declarations: [
    AppComponent,
    CursusListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    MatButtonModule,
    MatCardModule,
    MatInputModule,
    MatListModule,
    MatToolbarModule,
    BrowserAnimationsModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
    OwlDateTimeModule,
    OwlNativeDateTimeModule
  ],
  providers: [CursusService],
  bootstrap: [AppComponent]
})
export class AppModule { }
