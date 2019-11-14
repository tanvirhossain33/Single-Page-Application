import { Routes } from '@angular/router';
import { HomeComponent } from '../home/home.component';
import { DocumentComponent } from '../document/document.component';

export const appRoutes: Routes = [
    {
        path: '', component: HomeComponent,
        children: [
            { path: '', component: DocumentComponent}
              
        ]
    }
];
