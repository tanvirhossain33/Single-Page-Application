import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule} from '@angular/common/http';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { Ng2OrderModule } from 'ng2-order-pipe';
import {NgxPaginationModule} from 'ngx-pagination';

import { AppComponent } from './app.component';
import { appRoutes } from './module/app-routing/routes';
import { HomeComponent } from './module/home/home.component';
import { DocumentComponent } from './module/document/document.component';
import { DocumentCreateComponent } from './module/document/document-create/document-create.component';
import { DocumentListComponent } from './module/document/document-list/document-list.component';




@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    DocumentComponent,
    DocumentCreateComponent,
    DocumentListComponent
  ],
  imports: [
    NgbModule,
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    Ng2SearchPipeModule,
    Ng2OrderModule,
    NgxPaginationModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
