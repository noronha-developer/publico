function charToValue(c) {
    const nAsc = c.charCodeAt(0);

    // 0-9
    if (nAsc >= 48 && nAsc <= 57) {
        return nAsc - 48;
    }

    // A-Z
    if (nAsc >= 65 && nAsc <= 90) {
        return nAsc - 48;
    }

    return 0;
}

function validarCNPJ2026(cnpj) {

    let cNum = cnpj
        .toUpperCase()
        .replace(/\./g, "")
        .replace(/\//g, "")
        .replace(/-/g, "");

    if (cNum.length !== 14) {
        return false;
    }

    const peso1 = [5,4,3,2,9,8,7,6,5,4,3,2];
    const peso2 = [6,5,4,3,2,9,8,7,6,5,4,3,2];

    let soma = 0;

    // DV1
    for (let i = 0; i < 12; i++) {
        soma += charToValue(cNum[i]) * peso1[i];
    }

    let dv1 = 11 - (soma % 11);
    if (dv1 >= 10) dv1 = 0;

    // DV2
    soma = 0;

    for (let i = 0; i < 12; i++) {
        soma += charToValue(cNum[i]) * peso2[i];
    }

    soma += dv1 * peso2[12];

    let dv2 = 11 - (soma % 11);
    if (dv2 >= 10) dv2 = 0;

    return (
        parseInt(cNum[12]) === dv1 &&
        parseInt(cNum[13]) === dv2
    );
}