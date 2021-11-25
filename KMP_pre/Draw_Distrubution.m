x = CSVinfo(:,1).*1000;
y = CSVinfo(:,2).*1000;
nbins = 10; 
figure;
edges=[0:10:1000];
h1 = histogram(x,edges);
hold on
h2 = histogram(y,edges);
% h1.EdgeColor = 'r';
% h2.EdgeColor='b';

h1.Normalization = 'probability';
h2.Normalization = 'probability';
xlabel('10^-^6s');ylabel('probability');
legend('BF','KMS');
title('BF&KMP timespan comparing using: main String = 100, Search String=10,n=10000')
hold off