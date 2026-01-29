import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NbpService } from '../../services/nbp';

@Component({
  selector: 'app-currency-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './currency-list.html',
  styleUrl: './currency-list.css'
})
export class CurrencyList {
  selectedDate: string = '2025-01-16';
  message: string = '';
  currencies: any[] = [];

  constructor(private nbpService: NbpService) { }

  pobierzDane() {
    this.message = 'Pobieranie danych...';

    
    this.nbpService.getRates(this.selectedDate).subscribe({
      next: (response: any) => {
        this.message = response.message; 
        this.odswiezTabele(); 
      },
      error: (err: any) => {
        console.error(err);
        this.message = 'Błąd połączenia z serwerem!';
      }
    });
  }

  odswiezTabele() {
    
    this.nbpService.getAllSavedRates().subscribe((data: any[]) => {
      
      this.currencies = data.sort((a, b) => {
        return new Date(b.date).getTime() - new Date(a.date).getTime();
      });
    });
  }

  
  ngOnInit() {
    this.odswiezTabele();
  }
}
