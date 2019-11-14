import { OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

export class BaseComponent implements OnInit {

    service: any;
    toaster: ToastrService;

    constructor(service: any, toaster: ToastrService) {
        this.service = service;
        this.toaster = toaster;
    }

    ngOnInit() {}
}
