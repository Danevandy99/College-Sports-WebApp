import { toObservable } from '@angular/core/rxjs-interop';
import { Component, Input, Output, signal } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-date-dropdown',
  templateUrl: './date-dropdown.component.html',
  styleUrl: './date-dropdown.component.css'
})
export class DateDropdownComponent {

  protected options: string[] = [];

  protected selectedOption = signal<string | null>(this.getDefaultDate());
  @Input('selectedOption') set _selectedOption(value: string | null) {
    this.selectedOption.set(value);
  }
  @Output() protected selectedOptionChange = toObservable(this.selectedOption);

  constructor() {
    this.buildOptions();
  }

  private buildOptions() {
    // Get the current date
    const today = new Date();

    // Get the date from 6 months ago
    const sixMonthsAgo = new Date();
    sixMonthsAgo.setMonth(today.getMonth() - 6);

    // Get the date from 6 months from now
    const sixMonthsFromNow = new Date();
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

  private getDefaultDate(): string {
    const today = new Date();

    const date = new Date(Date.UTC(today.getFullYear(), today.getMonth(), today.getDate()));

    const result = date.toISOString();

    console.log(result);

    return result;
  }

  protected formatOption(option: string) {
    const date = new Date(option);

    // Check if the date is today
    const today = new Date();

    if (date.getFullYear() === today.getFullYear() && date.getMonth() === today.getMonth() && date.getDate() === today.getDate()) {
      return `${date.toLocaleDateString()} (Today)`;
    } else {
      return date.toLocaleDateString();
    }
  }
}
