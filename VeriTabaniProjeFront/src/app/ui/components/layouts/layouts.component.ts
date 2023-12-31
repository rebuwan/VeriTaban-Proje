import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';


@Component({
  selector: 'app-layouts',
  standalone: true,
  imports: [CommonModule, RouterModule, SidebarComponent, FooterComponent, HeaderComponent],
  templateUrl: './layouts.component.html',
  styleUrls: ['./layouts.component.css'],
})
export class LayoutsComponent {
  sideBar: boolean = true;

  degis(event: any){
    this.sideBar = event;
  }
}

