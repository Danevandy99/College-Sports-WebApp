import { Component, Input, Output, Signal, computed, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { toObservable, toSignal } from '@angular/core/rxjs-interop';
import { BasketballConferencesService } from 'src/app/services/basketball-conferences.service';
import { Conference } from 'src/api/models';
import { Utility } from 'src/utility';

@Component({
  selector: 'app-basketball-conferences-dropdown',
  templateUrl: './basketball-conferences-dropdown.component.html',
  styleUrl: './basketball-conferences-dropdown.component.css'
})
export class BasketballConferencesDropdownComponent {

  protected selectedConference = signal<string>("s:40~l:41~g:50");

  @Input('selectedConference') set _selectedConference(value: string) {
    this.selectedConference.set(value);
  }

  @Output() selectedConferenceChange = toObservable(this.selectedConference);

  protected allConferences = toSignal(this.basketballConferencesService.conferences$);

  protected groupsWithConferences: Signal<{ name: string, conferences: Conference[] }[]> = computed(() => {
    const allConferences = this.allConferences() ?? [];

    // Overall
    const top25: Conference = { uid: "Top25", name: "Top 25", shortName: "Top 25" };

    const power5: Conference = { uid: "Power6", name: "Power 6", shortName: "Power 6" };

    const televised: Conference = { uid: "Televised", name: "Televised", shortName: "Televised" };

    const overallConferences = [top25, power5, televised];

    const division1 = allConferences.find(conference => conference.uid === "s:40~l:41~g:50");

    if (division1) {
      overallConferences.unshift(division1);
    }

    const overallConferencesGroup = {
      name: "Overall",
      conferences: overallConferences,
    }

    // P5
    const p5Conferences = allConferences.filter(conference => !!conference.uid && Utility.p6ConferenceIds.includes(conference.uid));

    // Sort by name
    p5Conferences.sort((a, b) => {
      const aName = a.shortName ?? a.name ?? "";
      const bName = b.shortName ?? b.name ?? "";

      return aName.localeCompare(bName);
    });

    const p5ConferencesGroup = {
      name: "Power 6",
      conferences: p5Conferences,
    }

    const otherGroup = {
      name: "Other",
      conferences: allConferences.filter(conference => !p5Conferences.includes(conference) && !overallConferences.includes(conference)),
    }

    return [
      overallConferencesGroup,
      p5ConferencesGroup,
      otherGroup
    ]
  });

  constructor(private basketballConferencesService: BasketballConferencesService) { }
}
