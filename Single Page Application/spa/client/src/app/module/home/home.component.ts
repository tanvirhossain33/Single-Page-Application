import { Component, OnInit, Input  } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  @Input() title: string;

  isCollapsed = true;
  currentUserRole: string;

  toggleCollapsed(): void {
    this.isCollapsed = !this.isCollapsed;
  }

  constructor(private router: Router) { }

  ngOnInit() {
  }
}
