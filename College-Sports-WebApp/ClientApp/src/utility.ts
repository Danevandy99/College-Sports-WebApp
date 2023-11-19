import { Event } from "./api/models";

export class Utility {
  public static isGameFinished(game: Event): boolean {
    return game.competitions?.at(0)?.status?.type?.name === 'STATUS_FINAL';
  }

  public static isGameLive(game: Event): boolean {
    return game.competitions?.at(0)?.status?.type?.name === 'STATUS_IN_PROGRESS';
  }

  public static isGameScheduled(game: Event): boolean {
    return game.competitions?.at(0)?.status?.type?.name === 'STATUS_SCHEDULED';
  }

  public static getPeriodDisplayName(game: Event): string {
    const period = game.competitions?.at(0)?.status?.period ?? 0;
    if (period === 0) {
      return '';
    }

    switch (period) {
      case 1:
        return '1st';
      case 2:
        return '2nd';
      case 3:
        return 'OT';
      default:
        return `${period - 2}OT`;
    }
  }

  public static getPercentageOfGameRemaining(game: Event): number {
    const totalTimeInSeconds = 60 * 20 * 2;
    const currentPeriod = game.competitions?.at(0)?.status?.period ?? 0;
    const timeRemainingInSeconds = game.competitions?.at(0)?.status?.clock ?? 0;

    let totalSecondsElapsed = 0;

    // If the game is in the second period, add the first period to the total seconds elapsed
    if (currentPeriod > 1) {
      totalSecondsElapsed += (60 * 20);
    }

    // If the game is in the third or later period (OT), add the second period to the total seconds elapsed
    if (currentPeriod > 2) {
      totalSecondsElapsed += (60 * 20);
    }

    // Add any other overtime periods to the total seconds elapsed
    totalSecondsElapsed += Math.max(currentPeriod - 3, 0) * (60 * 5);

    // If we're in the first or second period, subtract the time remaining in the current period from 20 minutes in seconds
    if (currentPeriod <= 2) {
      totalSecondsElapsed += (60 * 20) - timeRemainingInSeconds;
    } else {
      totalSecondsElapsed += (60 * 5) - timeRemainingInSeconds;
    }

    if (!totalSecondsElapsed) {
      return 0;
    }

    return totalSecondsElapsed / totalTimeInSeconds;
  }
}
