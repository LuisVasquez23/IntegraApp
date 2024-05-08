export function formatDate(date: any): string {
  let formattedDate = '';

  if (date instanceof Date || !isNaN(Date.parse(date))) {
    const parsedDate = new Date(date);
    const month = String(parsedDate.getMonth() + 1).padStart(2, '0');
    const day = String(parsedDate.getDate()).padStart(2, '0');
    const year = parsedDate.getFullYear();
    formattedDate = `${month}/${day}/${year}`;
  } else {
    formattedDate = '';
  }

  return formattedDate;
}
