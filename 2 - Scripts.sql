** Query 1: Listar todos os clientes do estado de SP que tenham mais de 60% das parcelas pagas. **

SELECT *
FROM TB_CLIENTE C
OUTER APPLY (
	SELECT COUNT(*) AS QTD_PARCELAS
	FROM TB_PARCELA P1
	WHERE P1.ID_FINANCIAMENTO IN (SELECT ID_FINANCIAMENTO FROM TB_FINANCIAMENTO F1 WHERE F1.ID_CLIENTE = C.ID_CLIENTE)
) AS TODAS_PARCELAS
OUTER APPLY (
	SELECT COUNT(*) AS QTD_PARCELAS
	FROM TB_PARCELA P2
	WHERE P2.ID_FINANCIAMENTO IN (SELECT ID_FINANCIAMENTO FROM TB_FINANCIAMENTO F1 WHERE F1.ID_CLIENTE = C.ID_CLIENTE)
	AND P2.DT_PAGAMENTO IS NOT NULL
) AS PARCELAS_PAGAS
WHERE C.DS_UF = 'SP'
AND (TODAS_PARCELAS.QTD_PARCELAS*6) > PARCELAS_PAGAS.QTD_PARCELAS

**

** Query 2: Listar os primeiros 4 clientes que tenham alguma parcela com mais de 05 dias atrasadas (Data Vencimento maior que data atual E data pagamento nula). **

SELECT * FROM (
SELECT C.*
FROM TB_CLIENTE C
INNER JOIN TB_FINANCIAMENTO F ON C.ID_CLIENTE = F.ID_CLIENTE
INNER JOIN TB_PARCELA P ON F.ID_FINANCIAMENTO = P.ID_FINANCIAMENTO
WHERE P.DT_PAGAMENTO IS NULL
AND (P.DT_VENCIMENTO + INTERVAL '5' DAY) >= SYSDATE)
WHERE ROWNUM <= 4

**

** Query 3: Listar todos os clientes que já atrasaram em algum momento duas ou mais parcelas em mais de 10 dias, e que o valor do financiamento seja maior que R$ 10.000,00.. **

SELECT *
FROM TB_CLIENTE C
INNER JOIN TB_FINANCIAMENTO F ON C.ID_CLIENTE = F.ID_CLIENTE
OUTER APPLY (
	SELECT COUNT(*) AS QTD_PARCELAS
	FROM TB_PARCELA P
	WHERE P.DT_PAGAMENTO IS NOT NULL
	AND P.ID_FINANCIAMENTO IN (SELECT ID_FINANCIAMENTO FROM TB_FINANCIAMENTO F1 WHERE F1.ID_CLIENTE = C.ID_CLIENTE)
	AND extract(day from P.DT_PAGAMENTO - P.DT_VENCIMENTO) > 10
) AS PARCELAS_ATRASADAS
WHERE F.VL_VALOR_TOTAL > 10000
AND PARCELAS_ATRASADAS.QTD_PARCELAS > 2

**