import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CursusComponent } from './cursus/cursus.component';
import { CursussenComponent } from './cursussen/cursussen.component';
import { CursusAddEditComponent } from './cursus-add-edit/cursus-add-edit.component';
import { CursusService } from './services/cursus.service';
import { JsonMapper } from './services/cursus.mapper';

@NgModule({
  declarations: [
    AppComponent,
    CursusComponent,
    CursussenComponent,
    CursusAddEditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    CursusService,
    JsonMapper
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }