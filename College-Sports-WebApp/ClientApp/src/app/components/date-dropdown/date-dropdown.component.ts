import { toObservable } from '@angular/core/rxjs-interop';
import { Component, Input, Output, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Utility } from 'src/utility';

@Component({
  selector: 'app-date-dropdown',
  templateUrl: './date-dropdown.component.html',
  styleUrl: './date-dropdown.component.css'
})
export class DateDropdownComponent {

  protected options: string[] = [];

  protected selectedOption = signal<string | null>(Utility.getDefaultDate());
  @Input('selectedOption') set _selectedOption(value: string | null) {
    this.selectedOption.set(value);
  }
  @Output() protected selectedOptionChange = toObservable(this.selectedOption);

  constructor() {
    this.buildOptions();
  }

  private buildOptions() {
    // Get the current date
    const today = new Date(Date.UTC(new Date().getFullYear(), new Date().getMonth(), new Date().getDate()));

    // Get the date from 6 months ago
    const sixMonthsAgo = new Date(Date.UTC(new Date().getFullYear(), new Date().getMonth(), new Date().getDate()));
    sixMonthsAgo.setMonth(today.getMonth() - 6);

    // Get the date from 6 months from now
    const sixMonthsFromNow = new Date(Date.UTC(new Date().getFullYear(), new Date().getMonth(), new Date().getDate()));
    sixMonthsFromNow.setMonth(today.getMonth() + 6);

    // Create an array of dates between the two dates
    const dates: Date[] = [];
    let currentDate = sixMonthsAgo;

    while (currentDate <= sixMonthsFromNow) {
      dates.push(new Date(currentDate));
      currentDate.setDate(currentDate.getDate() + 1);
    }

    // Format the dates and add them to the options array
    for (const date of dates) {
      this.options.push(date.toISOString());
    }
  }



  protected formatOption(option: string) {
    const date = new Date(option);

    // Check if the date is today
    const today = new Date(Date.UTC(new Date().getFullYear(), new Date().getMonth(), new Date().getDate()));

    if (date.getFullYear() === today.getFullYear() && date.getMonth() === today.getMonth() && date.getDate() === today.getDate()) {
      return `${date.toLocaleDateString()} (Today)`;
    } else {
      return date.toLocaleDateString();
    }
  }
}
