import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { CurrencyList } from './components/currency-list/currency-list';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, CurrencyList],
  // TU BYŁ BŁĄD -> Zmieniamy na krótkie nazwy:
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class AppComponent {
  title = 'NbpFrontend';
}
