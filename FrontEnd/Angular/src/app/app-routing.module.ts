import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CursusComponent } from './cursus/cursus.component';
import { CursussenComponent } from './cursussen/cursussen.component';
import { CursusAddEditComponent } from './cursus-add-edit/cursus-add-edit.component';

const routes: Routes = [
  { path: '', component: CursussenComponent, pathMatch: 'full' },
  { path: 'cursus/:id', component: CursusComponent },
  { path: 'add', component: CursusAddEditComponent },
  { path: 'cursus/edit/:id', component: CursusAddEditComponent },
  { path: '**', redirectTo: '/' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
